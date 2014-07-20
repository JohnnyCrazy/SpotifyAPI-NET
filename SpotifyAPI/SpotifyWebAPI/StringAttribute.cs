using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SpotifyAPI.SpotifyWebAPI
{
    public class StringAttribute : Attribute
    {
        public String Text {get;set;}
        public StringAttribute(String text)
        {
            this.Text = text;
        }
    }
}
