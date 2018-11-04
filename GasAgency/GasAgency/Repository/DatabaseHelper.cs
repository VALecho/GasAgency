using GasAgency.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GasAgency.Repository
{
    public class DatabaseHelper
    {
        readonly SQLiteAsyncConnection database;

        public DatabaseHelper(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Client>().Wait();
            database.CreateTableAsync<Hawker>().Wait();
            database.CreateTableAsync<Product>().Wait();
            database.CreateTableAsync<ProductCost>().Wait();
            database.CreateTableAsync<Sale>().Wait();
            database.CreateTableAsync<Expense>().Wait();
            database.CreateTableAsync<HawkerSale>().Wait();
        }

        #region Client
        public Task<List<Client>> GetClientsAsync()
        {
            return database.Table<Client>().ToListAsync();
        }

        public Task<Client> GetClientAsync(int id)
        {
            return database.Table<Client>().Where(i => i.ClientId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveClientAsync(Client item)
        {
            if (item.ClientId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteClientAsync(Client item)
        {
            return database.DeleteAsync(item);
        }
        #endregion

        #region Hawker
        public Task<List<Hawker>> GetHawkersAsync()
        {
            return database.Table<Hawker>().ToListAsync();
        }

        public Task<Hawker> GetHawkerAsync(int id)
        {
            return database.Table<Hawker>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveHawkerAsync(Hawker item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteHawkerAsync(Hawker item)
        {
            return database.DeleteAsync(item);
        }
        #endregion

        #region Product
        public Task<List<Product>> GetProductsAsync()
        {
            return database.Table<Product>().ToListAsync();
        }

        public Task<Product> GetProductAsync(int id)
        {
            return database.Table<Product>().Where(i => i.ProductId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveProductAsync(Product item)
        {
            if (item.ProductId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteProductAsync(Product item)
        {
            return database.DeleteAsync(item);
        }
        #endregion

        #region ProductCost
        public Task<List<ProductCost>> GetProductCostsAsync()
        {
            return database.Table<ProductCost>().ToListAsync();
        }

        public Task<ProductCost> GetProductCostAsync(int id)
        {
            return database.Table<ProductCost>().Where(i => i.ProductId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveProductCostAsync(ProductCost item)
        {
            if (item.ProductCostId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteProductCostAsync(ProductCost item)
        {
            return database.DeleteAsync(item);
        }
        #endregion

        #region Sales
        public Task<List<Sale>> GetSalesAsync()
        {
            return database.Table<Sale>().ToListAsync();
        }

        public Task<Sale> GetSaleAsync(int id)
        {
            return database.Table<Sale>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveSaleAsync(Sale sale)
        {
            if (sale.Id != 0)
            {
                return database.UpdateAsync(sale);
            }
            else
            {
                return database.InsertAsync(sale);
            }
        }

        public Task<int> DeleteSaleAsync(Sale sale)
        {
            return database.DeleteAsync(sale);
        }
        #endregion

        #region Expenses
        public Task<List<Expense>> GetExpensesAsync()
        {
            return database.Table<Expense>().ToListAsync();
        }

        public Task<Expense> GetExpenseAsync(int id)
        {
            return database.Table<Expense>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveExpenseAsync(Expense Expense)
        {
            if (Expense.Id != 0)
            {
                return database.UpdateAsync(Expense);
            }
            else
            {
                return database.InsertAsync(Expense);
            }
        }

        public Task<int> DeleteExpenseAsync(Expense Expense)
        {
            return database.DeleteAsync(Expense);
        }
        #endregion

        #region Purchases
        public Task<List<Purchase>> GetPurchasesAsync()
        {
            return database.Table<Purchase>().ToListAsync();
        }

        public Task<Purchase> GetPurchaseAsync(int id)
        {
            return database.Table<Purchase>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SavePurchaseAsync(Purchase Purchase)
        {
            if (Purchase.Id != 0)
            {
                return database.UpdateAsync(Purchase);
            }
            else
            {
                return database.InsertAsync(Purchase);
            }
        }

        public Task<int> DeletePurchaseAsync(Purchase Purchase)
        {
            return database.DeleteAsync(Purchase);
        }
        #endregion

        #region HawkerSales
        public Task<List<HawkerSale>> GetHawkerSalesAsync()
        {
            return database.Table<HawkerSale>().ToListAsync();
        }

        public Task<HawkerSale> GetHawkerSaleAsync(int id)
        {
            return database.Table<HawkerSale>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveHawkerSaleAsync(HawkerSale HawkerSale)
        {
            if (HawkerSale.Id != 0)
            {
                return database.UpdateAsync(HawkerSale);
            }
            else
            {
                return database.InsertAsync(HawkerSale);
            }
        }

        public Task<int> DeleteHawkerSaleAsync(HawkerSale HawkerSale)
        {
            return database.DeleteAsync(HawkerSale);
        }
        #endregion
    }
}
