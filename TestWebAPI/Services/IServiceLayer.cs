using TestWebAPI.Models;

namespace TestWebAPI.Services
{
    /// <summary>
    /// This service layer takes care of all the business requirements as per client's need.
    /// </summary>
    public interface IServiceLayer
    {

        /// <summary>
        /// This function is fetching data based on a given key
        /// </summary>
        /// <param name="key">Input key for which data is requested</param>
        /// <returns>It returns key value pair for matching key</returns>
        string GetDataByKey(string key);


        /// <summary>
        /// This API is adding data requested by client in format of Key value pair. This API also ensuring not to insert duplicate keys.
        /// </summary>
        /// <param name="dataStore">Parameter to receive input key value pairs to be inserted </param>
        /// <returns>Returns status code. 0 if no data inserted and 1 if data inserted</returns>
        int AddData(string key, RequestPayload requestPayload);


        /// <summary>
        /// This API updating value of any given key which is available in memory
        /// </summary>
        /// <param name="dataStore">Parameter which have key with the new value to be updated</param>
        /// <returns>Returns status code. 0 if no data updated and 1 if data updated</returns>
        int UpdateData(string key, RequestPayload requestPayload);
    }
}
