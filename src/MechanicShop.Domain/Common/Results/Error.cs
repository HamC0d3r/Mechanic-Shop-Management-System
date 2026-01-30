namespace MechanicShop.Domain.Common.Results;

public readonly record struct Error
{
    public string Code { get; }
    public string Description { get; }
    public ErrorKind Type { get; }
    public Error(string code , string description, ErrorKind type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    public static Error Failure(string code = nameof(Failure), string description = "General failure.") =>
        new Error(code, description, ErrorKind.Failure);

    public static Error Unexpected(string code = nameof(Unexpected), string description = "Unecpected") =>
        new Error(code, description, ErrorKind.Unexpected);
    
    public static Error Validation(string code = nameof(Validation), string description = "Validation ") =>
        new Error(code, description, ErrorKind.Validation);

    public static Error Conflict( string code = nameof(Conflict), string description = "Conflect") =>
        new Error(code, description, ErrorKind.Conflect);

    public static Error NotFound( string code = nameof(NotFound), string description = "NotFound") =>
        new Error(code, description, ErrorKind.NotFound);

    public static Error Unauthorized( string code = nameof(Unauthorized), string description = "Unauthorized") =>
        new Error(code, description, ErrorKind.Unauthorized);

    public static Error Forbidden( string code = nameof(Forbidden), string description = "Forbidden") => 
        new Error(code, description, ErrorKind.Forbidden);

}
