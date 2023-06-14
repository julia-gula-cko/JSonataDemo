using System;
using System.ComponentModel;
using Gateway.Extensions.Utils;

namespace Jsonata.Net.Native.Eval;

    /// <summary>
    /// Represents a Base-32 encoded entity identifier
    /// </summary>
    [TypeConverter(typeof(IdConverter))]
    public sealed class Id : IEquatable<Id>
    {
        private readonly string? _prefix;
        private readonly Guid _decodedValue;
        private string _formattedValue;

        public Id(string? prefix, Guid value) : this(prefix, value, null!) { }

        private Id(string? prefix, Guid value, string formattedValue)
        {
            _prefix = prefix;
            _decodedValue = value;
            _formattedValue = formattedValue;
        }

        /// <summary>
        /// Gets the formatted value of the Id
        /// </summary>
        public string Value
        {
            get
            {
                if (_formattedValue == null)
                {
                    _formattedValue = GetPrefix() + Base32.Encode(_decodedValue.ToByteArray());
                }

                return _formattedValue;
            }
        }

        private string GetPrefix()
        {
            if (string.IsNullOrWhiteSpace(_prefix))
                return string.Empty;

            return _prefix + "_";
        }

        public Guid ToGuid() => _decodedValue;

        public bool Equals(Id? other)
        {
            if (other is null)
                return false;

            if (Object.ReferenceEquals(this, other))
                return true;

            return other.GetHashCode() == GetHashCode();
        }

        public override bool Equals(object? obj) => Equals(obj as Id);

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + GetPrefix().GetHashCode(StringComparison.InvariantCulture);
                hash = hash * 23 + _decodedValue.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            // Required for legacy compatibility
            if (string.IsNullOrWhiteSpace(_prefix))
                return _decodedValue.ToString();    
            
            return Value;
        }

        /// <summary>
        /// Attempts to parse an Id from the specified formatted Id value
        /// </summary>
        /// <param name="value">The value to parse</param>
        /// <param name="id">The parsed Id if successful</param>
        /// <returns>True if the Id could be parsed, otherwise False</returns>
        public static bool TryParse(string value, out Id? id)
        {
            id = null;

            if (string.IsNullOrEmpty(value))
                return false;

            // Required for backwards compatibility pre-base32 id change
            if (Guid.TryParse(value, out Guid guidId))
            {
                id = new Id(null, guidId);
                return true;
            }

            string?[] parts = value.Split('_');
            if (parts.Length != 2)
                return false;

            try
            {
                guidId = new Guid(Base32.Decode(parts[1]!));
                id = new Id(parts[0], guidId, value);

                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public static Guid GetGuid(string value)
        {
            Guid guid;

            if (TryParse(value, out Id? id))
            {
                guid = id!.ToGuid();
            }
            else
            {
                throw new IdParseException(value);
            }

            return guid;
        }

        /// <summary>
        /// Creates a new Id with the specified prefix and new Guid
        /// </summary>
        /// <param name="prefix">The Id prefix</param>
        public static Id NewId(string? prefix) => new Id(prefix, Guid.NewGuid());

        public static bool operator ==(Id id1, Id id2)
        {
            if (id1 is null)
            {
                // null == null
                if (id2 is null)
                    return true;

                return false;
            }

            return id1.Equals(id2);
        }

        public static bool operator !=(Id id1, Id id2) => !(id1 == id2);
    }

public class IdParseException : Exception
{
    public IdParseException()
    { }

    public IdParseException(string idValue) : base($"Error parsing id:  {idValue}")
    { }

    public IdParseException(string message, Exception innerException) : base(message, innerException)
    { }
}