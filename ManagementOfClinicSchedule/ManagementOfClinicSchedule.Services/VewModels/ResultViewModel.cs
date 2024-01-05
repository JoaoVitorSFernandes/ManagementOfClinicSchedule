namespace ManagementOfClinicSchedule.Services.VewModels
{
    public class ResultViewModel<T> where T : class
    {
        public T Data { get; set; }
        public List<string> Erros { get; set; } = new();

        public ResultViewModel(T data)
        {
            Data = data;
        }

        public ResultViewModel(string errorMessage)
        {
            Erros.Add(errorMessage);
        }

        public ResultViewModel(IEnumerable<string> errorMessages)
        {
            Erros.AddRange(errorMessages);
        }

        public ResultViewModel(T data, string errorMessage)
        {
            Data = data;
            Erros.Add(errorMessage);
        }
    }
}
