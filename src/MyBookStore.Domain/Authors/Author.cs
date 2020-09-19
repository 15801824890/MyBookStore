using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyBookStore.Authors
{
    /// <summary>
    /// Inherited from FullAuditedAggregateRoot<Guid> :not deleted in the database, but just marked as deleted
    /// </summary>
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// two ways of setting the name (in both cases, we validate the name):
        /// In the constructor, while creating a new author.
        /// Using the ChangeName method to update the name later.
        /// </summary>
        public string Name { get; private set; }

        public DateTime BirthDate { get; set; }
        public string ShortBio { get; set; }

        private Author()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        /// <summary>
        /// internal to force to use these methods only in the domain layer,
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="shortBio"></param>
        internal Author(
            Guid id,
            [NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string shortBio = null)
            : base(id)
        {
            SetName(name);
            BirthDate = birthDate;
            ShortBio = shortBio;
        }

        internal Author ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            //Check class is an ABP Framework utility class to help you while checking method arguments(it throws ArgumentException on an invalid case).
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: AuthorConsts.MaxNameLength
            );
        }
    }
}