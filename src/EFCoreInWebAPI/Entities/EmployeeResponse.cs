namespace EFCoreInWebAPI.Entities
{
    public class EmployeeResponse
    {
        public EmployeeResponse(int id, string name, string family)
        {
            Id = id;
            Name = name;
            Family = family;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
