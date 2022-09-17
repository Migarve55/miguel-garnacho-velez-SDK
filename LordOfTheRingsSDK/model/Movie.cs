
namespace LordOfTheRingsSDK;

public class Movie {

    public string _Id { get; set; }

    public string Name { get; set; }

    public int RuntimeInMinutes { get; set; }
    
    public float BudgetInMillions { get; set; }

    public float BoxOfficeRevenueInMillions { get; set; }

    public int AcademyAwardNominations { get; set; }

    public int AcademyAwardWins { get; set; }

    public float RottenTomatoesScore { get; set; }

}
