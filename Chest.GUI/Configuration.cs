using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chest.GUI
{
    public static class Configuration
    {
        public static JsonSerializerSettings SerializerOptions = new ()
		{
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
		};

    }
}
