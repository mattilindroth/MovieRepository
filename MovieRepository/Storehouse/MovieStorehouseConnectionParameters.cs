namespace MovieRepository.Storehouse
{
    internal class MovieStorehouseConnectionParameters
    {
        
        public MovieStorehouseConnectionParameters(string endPointUri, string primaryKey, string databaseId, string containerId) 
        {
            EndPointUri = endPointUri;
            PrimaryKey = primaryKey;
            DatabaseId = databaseId; ;
            ContainerId = containerId;
            
        }
        public string DatabaseId { get; set; }
        public string ContainerId { get; set; }
        public string EndPointUri { get; set; }
        public string PrimaryKey { get; set; }
        

    }
}
