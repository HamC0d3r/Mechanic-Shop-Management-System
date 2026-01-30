using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MechanicShop.Domain.Common.Results;

public static class Result
{
    public static Success Success => default;
    public static Created Created => default;
    public static Deleted Deleted => default;
    public static Updated Updated => default;

}
public sealed class Result<TValue> : IResult<TValue>
{
    private readonly TValue? _value = default;
    private readonly List<Error>? _errors = null;
    
    public bool IsSuccess { get; init; }
    public bool IsError => !IsSuccess;
    public List<Error> Errors => IsError ? _errors! : [];
    public TValue Value => IsSuccess ? _value! : default!;
    public Error TopError => IsError ? _errors!.First() : default!;

    [JsonConstructor]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("For serialization only", true)]
    public Result(TValue? value, List<Error>? errors, bool isSuccess)
    {
        if (isSuccess)
        {
            IsSuccess = isSuccess;
            _value = value ?? throw new ArgumentNullException(nameof(value), "Value cannot be null for a successful result");
            _errors = [];

        }
        else
        {
            if (errors == null || errors.Count == 0)
                throw new ArgumentException("Errors list cannot be empty", nameof(errors));

            _errors = errors;
            IsSuccess = isSuccess;
            _value = default!;
        }
    }
    private Result(Error error)
    {
        IsSuccess = false;
        _errors = new List<Error> { error };
    }
    private Result(List<Error> errors)
    {
        if (errors.Count == 0 || errors is null)
            throw new ArgumentException("Errors list cannot be empty", nameof(errors));
        
        IsSuccess = false;
        _errors = errors;
    }
    private Result(TValue value)
    {
        if(value is null)
            throw new ArgumentNullException(nameof(value), "Value cannot be null for a successful result");

        IsSuccess = true;
        _value = value;
    }
    
    
    public TNextValue Match<TNextValue>(Func<TValue, TNextValue> onSuccess, Func<List<Error>, TNextValue> onError)
    {
        return IsSuccess ? onSuccess(_value!) : onError(_errors!);
    }
    public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value);
    public static implicit operator Result<TValue>(Error error) => new Result<TValue>(error);
    public static implicit operator Result<TValue>(List<Error> errors) => new Result<TValue>(errors);

}
public readonly record struct Success;
public readonly record struct Created;
public readonly record struct Deleted;
public readonly record struct Updated;