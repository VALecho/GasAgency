﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GasAgency.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(T item);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
