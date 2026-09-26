namespace Proforientation_Quiz.Domain.Models
{
    public class TraitsVector
    {
        public double People { get; set; }
        public double Creative { get; set; }
        public double Analytical { get; set; }
        public double Practical { get; set; }

        public double ManhattanDistance(TraitsVector other)
        {
            return Math.Abs(People - other.People) +
                   Math.Abs(Creative - other.Creative) +
                   Math.Abs(Analytical - other.Analytical) +
                   Math.Abs(Practical - other.Practical);
        }

        public static TraitsVector TraitsAverage(IEnumerable<TraitsVector> traits)
        {
            var list=traits.ToList();
            if (!list.Any()) return new TraitsVector ();

            return new TraitsVector
            {
                People = list.Average(t => t.People),
                Creative = list.Average(t => t.Creative),
                Analytical = list.Average(t => t.Analytical),
                Practical = list.Average(t => t.Practical)

            };
        }
    }
}
