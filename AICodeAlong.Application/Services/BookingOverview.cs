namespace AICodeAlong.Application.Services;

// Det som visas i bokningslistan: bokningen plus rummets namn.
public record BookingOverview(
    int BookingId,
    int RoomId,
    string RoomName,
    string BookedBy,
    DateOnly Date,
    int Guests);
