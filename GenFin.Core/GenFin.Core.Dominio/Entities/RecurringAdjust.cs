namespace GenFin.Core.Dominio.Entities
{
    public class RecurringAdjust : Entity
    {
        public int IdRecurringTransaction { get; set; }
        public DateTime DateStart { get; set; }
        public decimal Percent { get; set; }

        public RecurringTransaction RecurringTransaction { get; set; }
    }
}