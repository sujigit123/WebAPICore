using System;
using System.Linq;
using TestWebAPI.Models;

namespace TestWebAPI.Services
{
    /// <summary>
    /// This service layer takes care of all the business requirements as per client's need.
    /// </summary>
    public class ServiceLayer : IServiceLayer
    {
        private readonly APIContext _apiContext;
        public ServiceLayer(APIContext apiContext)
        {
            _apiContext = apiContext;
        }        

        /// <summary>
        /// This function is fetching data based on a given key
        /// </summary>
        /// <param name="key">Input key for which data is requested</param>
        /// <returns>It returns key value pair for matching key</returns>
        public string GetDataByKey(string key)
        {
            string value = string.Empty;
            try
            {
                if (_apiContext.dataStores.SingleOrDefault(k => k.Key.Trim().ToLower() == key.Trim().ToLower()) != null)
                {
                    value = _apiContext.dataStores.SingleOrDefault(k => k.Key.Trim().ToLower() == key.Trim().ToLower()).Value;
                }
                else
                {
                    value = "Data not available with given key";
                }
                
            }
            catch (Exception ex)
            {
                value = ex.Message;
            }
            
            return value;
        }

        /// <summary>
        /// This API is adding data requested by client in format of Key value pair. This API also ensuring not to insert duplicate keys.
        /// </summary>
        /// <param name="dataStore">Parameter to receive input key value pairs to be inserted </param>
        /// <returns>Returns status code. 0 if no data inserted and 1 if data inserted</returns>
        public int AddData(string key, RequestPayload requestPayload)
        {
            int addStatus = 0;
            try
            {
                if (_apiContext.dataStores.SingleOrDefault(k => k.Key.Trim().ToLower() == key.Trim().ToLower()) == null)
                {
                    _apiContext.dataStores.Add(new DataStore { Key = key.Trim(), Value = requestPayload.value.Trim() });
                    _apiContext.SaveChanges();
                    addStatus = 1;
                }
                else
                    addStatus = 0;
            }
            catch (Exception ex)
            {
                addStatus = -1;
            }

            return addStatus;
        }

        /// <summary>
        /// This API updating value of any given key which is available in memory
        /// </summary>
        /// <param name="dataStore">Parameter which have key with the new value to be updated</param>
        /// <returns>Returns status code. 0 if no data updated and 1 if data updated</returns>
        public int UpdateData(string key, RequestPayload requestPayload)
        {
            int updateStatus = 0;
            try
            {
                DataStore tempDataStore = _apiContext.dataStores.SingleOrDefault(k => k.Key.Trim().ToLower() == key.Trim().ToLower());
                if (tempDataStore != null)
                {
                    tempDataStore.Value = requestPayload.value;
                    _apiContext.Update(tempDataStore);
                    _apiContext.SaveChanges();
                    updateStatus = 1;
                }
                else
                    updateStatus = 0;
            }
            catch (Exception ex)
            {
                updateStatus = -1;
            }

            return updateStatus;
        }
    }    
}
