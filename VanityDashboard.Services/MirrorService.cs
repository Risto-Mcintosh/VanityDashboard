using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VanityDashboard.Data;

namespace VanityDashboard.Servies
{
    public class MirrorService : IMirrorService
    {
        private readonly AppDbContext db;

        public MirrorService(AppDbContext db)
        {
            this.db = db;
        }
        

        public Mirror GetMirror(Sizes size)
        {
            return db.Mirrors.FirstOrDefault(m => m.Size == size);
        }

        public IEnumerable<Mirror> GetMirrors()
        {
            return db.Mirrors;
        }

        public Mirror UpdateMirror(Mirror mirror)
        {
            var entity = db.Mirrors.Attach(mirror);
            entity.State = EntityState.Modified;
            return mirror;
        }
    }
}
