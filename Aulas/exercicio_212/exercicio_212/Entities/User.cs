using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio_212.Entities {
    internal class User {
        public int Code { get; set; }

        public override int GetHashCode() {
            return Code.GetHashCode();
        }

        public override bool Equals(object? obj) {
            if (!(obj is User))
                return false;

            User other = obj as User;
            return Code.Equals(other.Code);
        }
    }
}
