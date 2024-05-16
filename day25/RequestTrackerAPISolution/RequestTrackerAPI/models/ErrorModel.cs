namespace RequestTrackerAPI.models
{
    public class ErrorModel
    {
        private int v;
        private string message1;

        public ErrorModel(int v, string message1)
        {
            this.v = v;
            this.message1 = message1;
        }

        public int message { get; set; }
        public string description { get; set; }
    }
}