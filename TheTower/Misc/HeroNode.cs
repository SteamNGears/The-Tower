

namespace TheTower
{
    class HeroNode
    {
        private string heroName;
        private string userNamed;
        private string imagePath;
        private string heroClass ="";

        public HeroNode(string heroName)
        {
            this.heroName = heroName;
            updateImagePath();
        }
        public string HeroClass
        {
            get
            {
                return this.heroClass;
            }
            set
            {
                this.heroClass = value;
            }
        }
        public string UserNamed
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
            string path = System.IO.Directory.GetCurrentDirectory();
            if(heroName.Length != 0)
            {               
                imagePath = string.Format(path + "\\bitmap\\hero{0} 50x50.png", heroName[5]);
            }
            else
            {
                imagePath = path + "\\bitmap\\dice0.png";
            }           
        }

        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }
        }

        
    }
}
