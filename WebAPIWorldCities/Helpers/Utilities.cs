namespace WebAPIWorldCities.Helpers;

public static class Utilities
{
    // Normalization helper to ensure all country names are stored Capitalized irrespective of how
    // the user writes it
    public static string Normalize(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return name;

        name = name.Trim().ToLower();

        return char.ToUpper(name[0]) + name[1..];
    }
}
