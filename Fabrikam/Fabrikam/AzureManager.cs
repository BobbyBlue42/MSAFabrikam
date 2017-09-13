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
        private IMobileServiceTable<Item> itemsTable;
        private IMobileServiceTable<Favourite> favouritesTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("https://msafabrikam.azurewebsites.net");
            this.itemsTable = this.client.GetTable<Item>();
            this.favouritesTable = this.client.GetTable<Favourite>();
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

        public async Task<List<Item>> GetItems()
        {
            return await this.itemsTable.ToListAsync();
        }

        public async Task<List<Favourite>> GetFavourites()
        {
            return await this.favouritesTable.ToListAsync();
        }

        public async Task PostFavouritesInformation(Favourite favourite)
        {
            await this.favouritesTable.InsertAsync(favourite);
        }

        public async Task UpdateFavouritesInformation(Favourite favourite)
        {
            await this.favouritesTable.UpdateAsync(favourite);
        }

        public async Task DeleteFavouritesInformation(Favourite favourite)
        {
            await this.favouritesTable.DeleteAsync(favourite);
        }
    }
}
