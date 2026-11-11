namespace AICodeAlong.Application.Services;

// Resultatet när man försöker skapa en bokning.
public record BookingResult(bool Success, string? ErrorMessage)
{
    public static BookingResult Ok() => new(true, null);
    public static BookingResult Fail(string message) => new(false, message);
}
