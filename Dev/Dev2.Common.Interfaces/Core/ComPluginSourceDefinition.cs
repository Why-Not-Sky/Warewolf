﻿using System;

namespace Dev2.Common.Interfaces.Core
{
    public class ComPluginSourceDefinition : IComPluginSource
    {
        #region Equality members

        public bool Equals(IComPluginSource other)
        {
            return string.Equals(Name, other.Name) && Id.Equals(other.Id) && Equals(ClsId, other.ClsId) && string.Equals(ProgId, other.ProgId);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return false;
            }
            if(ReferenceEquals(this, obj))
            {
                return true;
            }
            if(obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((PluginSourceDefinition)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (ProgId?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (ClsId.GetHashCode());
                return hashCode;
            }
        }

        public static bool operator ==(ComPluginSourceDefinition left, ComPluginSourceDefinition right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ComPluginSourceDefinition left, ComPluginSourceDefinition right)
        {
            return !Equals(left, right);
        }

        #endregion

        #region Implementation of IComPluginSource

        public string Name { get; set; }
        public Guid Id { get; set; }
        public string ProgId { get; set; }
        public string ClsId { get; set; }
        public IFileListing SelectedDll { get; set; }

        #endregion
    }
}