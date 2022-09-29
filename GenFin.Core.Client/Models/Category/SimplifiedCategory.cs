using BibliotecaPublica.Core.Entities;

namespace GenFin.Core.Client.Models.Category
{
    public class SimplifiedCategory : Entity
    {
        public string Name { get; set; }
        public bool ShowInCalendar { get; set; }
    }
}