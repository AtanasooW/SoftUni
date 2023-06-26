namespace AquaShop.Repositories
{
using System;
using System.Collections.Generic;
    using Models.Decorations.Contracts;
    using Contracts;
    using System.Linq;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> models;
        public IReadOnlyCollection<IDecoration> Models => (IReadOnlyCollection<IDecoration>)this.models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public void Add(IDecoration model)
        => this.models.Add(model);

        public IDecoration FindByType(string type)
        => this.models.FirstOrDefault(x => x.GetType().Name == type);

        public bool Remove(IDecoration model)
        => this.models.Remove(model);
    }
}
