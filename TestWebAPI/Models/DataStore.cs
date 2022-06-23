using System.ComponentModel.DataAnnotations;


namespace TestWebAPI.Models
{
    public class DataStore
    {
        [Key]     
        public string Key { get; set; }
       
        public string Value { get; set; }
    }

    public class RequestPayload
    {
        [MaxLength(1024, ErrorMessage = "Value should not exceed 1024 characters")]
        public string value { get; set; }
    }
}
