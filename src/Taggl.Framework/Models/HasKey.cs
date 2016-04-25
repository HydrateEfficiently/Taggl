using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Framework.Models
{
    public interface HasKey<TKey>
    {
        TKey Id { get; set; }
    }
}
