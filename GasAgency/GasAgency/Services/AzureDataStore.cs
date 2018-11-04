using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace GasAgency.Services
{
    public class AzureDataStore<T> : IDataStore<T>
    {
        bool isInitialized;
        IMobileServiceSyncTable<T> itemsTable;

        public MobileServiceClient MobileService { get; set; }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();
            //if (forceRefresh)
            //{
            //    await PullLatestAsync();
            //}
            return await itemsTable.ToEnumerableAsync();
        }

        public async Task<bool> AddItemAsync(T item)
        {
            await InitializeAsync();
            //await PullLatestAsync();
            await itemsTable.InsertAsync(item);
            //await SyncAsync();

            return true;
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            await InitializeAsync();
            await itemsTable.UpdateAsync(item);
            //await SyncAsync();

            return true;
        }

        public async Task<bool> DeleteItemAsync(T item)
        {
            await InitializeAsync();
            //await PullLatestAsync();
            await itemsTable.DeleteAsync(item);
            //await SyncAsync();

            return true;
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            MobileService = new MobileServiceClient(App.AzureBackendUrl)
            {
                SerializerSettings = new MobileServiceJsonSerializerSettings
                {
                    CamelCasePropertyNames = true
                }
            };

            var path = "gasagency.db";
            path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);
            var store = new MobileServiceSQLiteStore(path);

            store.DefineTable<T>();
            await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());
            itemsTable = MobileService.GetSyncTable<T>();

            isInitialized = true;
        }

        public async Task<bool> PullLatestAsync()
        {
            try
            {
                await itemsTable.PullAsync($"all{typeof(T).Name}", itemsTable.CreateQuery());
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"Unable to pull items: {ex.Message}");

                return false;
            }
            return true;
        }

        public async Task<bool> SyncAsync()
        {
            try
            {
                await MobileService.SyncContext.PushAsync();
                if (!(await PullLatestAsync().ConfigureAwait(false)))
                    return false;
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult == null)
                {
                    //Debug.WriteLine($"Unable to sync, that is alright as we have offline capabilities: {exc.Message}");

                    return false;
                }
                foreach (var error in exc.PushResult.Errors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //Update failed, reverting to server's copy.
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        // Discard local change.
                        await error.CancelAndDiscardItemAsync();
                    }

                    //Debug.WriteLine($"Error executing sync operation. Item: {error.TableName} ({error.Item["id"]}). Operation discarded.");
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"Unable to sync items: {ex.Message}");
                return false;
            }

            return true;
        }
    }
}