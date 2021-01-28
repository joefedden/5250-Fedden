﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Honda S2000", Description="237 hp/162 lb-ft", Value=9 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Volkswagen Golf GTI", Description="220 hp/258 lb-ft", Value=8},
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Mazda RX-7 FD", Description="238 hp/218 lb-ft", Value=5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Toyota MR2 GT-S Turbo", Description="242 hp/224 lb-ft", Value=4 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Mitsubishi Lancer Evolution IX", Description="286 hp/289 lb-ft", Value=6 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Acura NSX", Description="270 hp/210 lb-ft", Value=7 }
            };
        }

        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}