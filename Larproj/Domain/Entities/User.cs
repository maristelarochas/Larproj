namespace Larproj.Domain.Entities;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string HashPassword { get; private set; }
    public int CurrentScore { get; private set; }
    public int? PartyId { get; private set; }

    public User(int id, string name, string email, string hashPassword, int currentScore, int? partyId)
    {
        Id = id;
        Name = name;
        Email = email;
        HashPassword = hashPassword;
        CurrentScore = currentScore;
        PartyId = partyId;
    }
}