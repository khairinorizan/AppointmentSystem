CREATE TABLE Booking
(
    BookingID INTEGER PRIMARY KEY IDENTITY,
    UserID INTEGER FOREIGN KEY REFERENCES SystemUser(UserID),
    BookingDate DATE,
    DeviceID INTEGER FOREIGN KEY REFERENCES Device(DeviceID),
    ProblemID INTEGER FOREIGN KEY REFERENCES Problem(ProblemID),
    Description VARCHAR(255)
);