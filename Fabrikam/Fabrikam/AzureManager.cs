using Fabrikam.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrikam
{
    class AzureManager
    {
        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<ItemModel> itemsTable;
        private IMobileServiceTable<FavouriteModel> favouritesTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("https://msafabrikam.azurewebsites.net");
            this.itemsTable = this.client.GetTable<ItemModel>();
            this.favouritesTable = this.client.GetTable<FavouriteModel>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task<List<ItemModel>> GetItems()
        {
            return await this.itemsTable.ToListAsync();
        }

        public async Task<List<FavouriteModel>> GetFavourites()
        {
            return await this.favouritesTable.ToListAsync();
        }

        public async Task PostFavouritesInformation(FavouriteModel favourite)
        {
            await this.favouritesTable.InsertAsync(favourite);
        }

        public async Task UpdateFavouritesInformation(FavouriteModel favourite)
        {
            await this.favouritesTable.UpdateAsync(favourite);
        }

        public async Task DeleteFavouritesInformation(FavouriteModel favourite)
        {
            await this.favouritesTable.DeleteAsync(favourite);
        }
    }
}
