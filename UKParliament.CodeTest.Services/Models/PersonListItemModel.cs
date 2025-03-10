namespace UKParliament.CodeTest.Services.Models;

public record PersonListItemModel(int Id,
                                  string FirstName,
                                  string LastName,
                                  DateOnly DateOfBirth,
                                  string DepartmentName,
                                  DateTime? LastUpdatedOn);