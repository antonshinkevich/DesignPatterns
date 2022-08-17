using System.Runtime.Serialization;
using System.Text;

namespace Decorator;

public class CodeBuilder
{
    private StringBuilder builder = new StringBuilder();
    private int indentLevel = 0;

    public CodeBuilder Indent()
    {
        indentLevel++;
        return this;
    }

    public override string ToString()
    {
        return builder.ToString();
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        ((ISerializable)builder).GetObjectData(info, context);
    }

    public StringBuilder Append(bool value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(byte value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(char value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(char value, int repeatCount)
    {
        return builder.Append(value, repeatCount);
    }

    public StringBuilder Append(char[]? value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(char[]? value, int startIndex, int charCount)
    {
        return builder.Append(value, startIndex, charCount);
    }

    public StringBuilder Append(decimal value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(double value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(short value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(int value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(long value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(object? value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(ReadOnlyMemory<char> value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(ReadOnlySpan<char> value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(sbyte value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(float value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(string? value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(string? value, int startIndex, int count)
    {
        return builder.Append(value, startIndex, count);
    }

    public StringBuilder Append(StringBuilder? value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(StringBuilder? value, int startIndex, int count)
    {
        return builder.Append(value, startIndex, count);
    }

    public StringBuilder Append(ushort value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(uint value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(ulong value)
    {
        return builder.Append(value);
    }

    public StringBuilder Append(ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        return builder.Append(ref handler);
    }

    public StringBuilder Append(IFormatProvider? provider, ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        return builder.Append(provider, ref handler);
    }

    public StringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0)
    {
        return builder.AppendFormat(provider, format, arg0);
    }

    public StringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1)
    {
        return builder.AppendFormat(provider, format, arg0, arg1);
    }

    public StringBuilder AppendFormat(IFormatProvider? provider, string format, object? arg0, object? arg1, object? arg2)
    {
        return builder.AppendFormat(provider, format, arg0, arg1, arg2);
    }

    public StringBuilder AppendFormat(IFormatProvider? provider, string format, params object?[] args)
    {
        return builder.AppendFormat(provider, format, args);
    }

    public StringBuilder AppendFormat(string format, object? arg0)
    {
        return builder.AppendFormat(format, arg0);
    }

    public StringBuilder AppendFormat(string format, object? arg0, object? arg1)
    {
        return builder.AppendFormat(format, arg0, arg1);
    }

    public StringBuilder AppendFormat(string format, object? arg0, object? arg1, object? arg2)
    {
        return builder.AppendFormat(format, arg0, arg1, arg2);
    }

    public StringBuilder AppendFormat(string format, params object?[] args)
    {
        return builder.AppendFormat(format, args);
    }

    public StringBuilder AppendJoin(char separator, params object?[] values)
    {
        return builder.AppendJoin(separator, values);
    }

    public StringBuilder AppendJoin(char separator, params string?[] values)
    {
        return builder.AppendJoin(separator, values);
    }

    public StringBuilder AppendJoin(string? separator, params object?[] values)
    {
        return builder.AppendJoin(separator, values);
    }

    public StringBuilder AppendJoin(string? separator, params string?[] values)
    {
        return builder.AppendJoin(separator, values);
    }

    public StringBuilder AppendJoin<T>(char separator, IEnumerable<T> values)
    {
        return builder.AppendJoin(separator, values);
    }

    public StringBuilder AppendJoin<T>(string? separator, IEnumerable<T> values)
    {
        return builder.AppendJoin(separator, values);
    }

    public StringBuilder AppendLine()
    {
        return builder.AppendLine();
    }

    // fixed
    public CodeBuilder AppendLine(string? value)
    {
        builder.AppendLine(value);
        return this;
    }

    public StringBuilder AppendLine(ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        return builder.AppendLine(ref handler);
    }

    public StringBuilder AppendLine(IFormatProvider? provider, ref StringBuilder.AppendInterpolatedStringHandler handler)
    {
        return builder.AppendLine(provider, ref handler);
    }

    public StringBuilder Clear()
    {
        return builder.Clear();
    }

    public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
    {
        builder.CopyTo(sourceIndex, destination, destinationIndex, count);
    }

    public void CopyTo(int sourceIndex, Span<char> destination, int count)
    {
        builder.CopyTo(sourceIndex, destination, count);
    }

    public int EnsureCapacity(int capacity)
    {
        return builder.EnsureCapacity(capacity);
    }

    public bool Equals(ReadOnlySpan<char> span)
    {
        return builder.Equals(span);
    }

    public bool Equals(StringBuilder? sb)
    {
        return builder.Equals(sb);
    }

    public StringBuilder.ChunkEnumerator GetChunks()
    {
        return builder.GetChunks();
    }

    public StringBuilder Insert(int index, bool value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, byte value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, char value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, char[]? value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, char[]? value, int startIndex, int charCount)
    {
        return builder.Insert(index, value, startIndex, charCount);
    }

    public StringBuilder Insert(int index, decimal value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, double value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, short value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, int value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, long value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, object? value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, ReadOnlySpan<char> value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, sbyte value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, float value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, string? value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, string? value, int count)
    {
        return builder.Insert(index, value, count);
    }

    public StringBuilder Insert(int index, ushort value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, uint value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Insert(int index, ulong value)
    {
        return builder.Insert(index, value);
    }

    public StringBuilder Remove(int startIndex, int length)
    {
        return builder.Remove(startIndex, length);
    }

    public StringBuilder Replace(char oldChar, char newChar)
    {
        return builder.Replace(oldChar, newChar);
    }

    public StringBuilder Replace(char oldChar, char newChar, int startIndex, int count)
    {
        return builder.Replace(oldChar, newChar, startIndex, count);
    }

    public StringBuilder Replace(string oldValue, string? newValue)
    {
        return builder.Replace(oldValue, newValue);
    }

    public StringBuilder Replace(string oldValue, string? newValue, int startIndex, int count)
    {
        return builder.Replace(oldValue, newValue, startIndex, count);
    }

    public string ToString(int startIndex, int length)
    {
        return builder.ToString(startIndex, length);
    }

    public int Capacity
    {
        get => builder.Capacity;
        set => builder.Capacity = value;
    }

    public char this[int index]
    {
        get => builder[index];
        set => builder[index] = value;
    }

    public int Length
    {
        get => builder.Length;
        set => builder.Length = value;
    }

    public int MaxCapacity => builder.MaxCapacity;
}