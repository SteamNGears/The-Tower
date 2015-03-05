using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTower
{
    class HeroNode
    {
        private String heroName;
        private String userNamed;
        private String imagePath;

        public HeroNode(String heroName)
        {
            this.heroName = heroName;
            updateImagePath();
        }

        public String UserNamed
        {
            get
            {
                return this.userNamed;
            }
            set
            {
                this.userNamed = value;
            }
        }

        public void updateImagePath()
        {
            String path = System.IO.Directory.GetCurrentDirectory();
            if(heroName.Length != 0)
            {               
                imagePath = String.Format(path + "/bitmap/hero{0} 50x50.jpg", heroName[5]);
            }
            else
            {
                imagePath = path + "/bitmap/dice0.png";
            }           
        }

        public String ImagePath
        {
            get
            {
                return this.imagePath;
            }
        }

    }
}
