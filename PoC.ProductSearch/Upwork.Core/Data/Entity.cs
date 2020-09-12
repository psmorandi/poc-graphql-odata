namespace Upwork.Core.Data
{
    using System;

    public abstract class Entity
    {
        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            return compareTo != null && this.Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode() * 907 + this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [Id={this.Id}]";
        }
    }
}