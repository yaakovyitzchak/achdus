using SimpleJSON;
using System.Collections.Generic;
using Jint.Native;
using UnityEngine;
using static UnityEngine.MonoBehaviour;
namespace Achdus
{
    public class Medabeir : Chai
    {
       
        public Dictionary<string, object> customMap = null;
        public Medabeir() : this(new Davar()) {}
		
        public Medabeir(Jint.Native.JsValue d) : this(
			new Davar(d)
		) {}
		
		public Medabeir(Davar data) : base(data) {
	
			customMap = data["materialMap"];
		}
		
		public Davar doochsoostiss = new Davar();

        public Material myMaterial;
        public Dictionary<string, Material> ClothMaterials = new Dictionary<string, Material>();
        public Dictionary<string, string> clothes = new Dictionary<string, string>() {
			{"shirt", "white"},

			{"pants", "pink" },
			{"hat", "black"},

			{"tzitzis", "white"},
			{"hair", "#826641"},
			{"face", "brown"},
			{"jacket","black"},
			{"pupal","black"},
			{"shoes","black"},
			{"yarmulka","black"},
			{"skin","#f9da84"},
			{"eye","white"}
		};

        public override void HeessCheel()
        {
            base.HeessCheel();
            MakeOutfit();
        }



        void MakeOutfit()
        {

            var renderers = (gameObject.GetComponentsInChildren<Renderer>());

            foreach (Renderer i in renderers)
            {
                int size = i.materials.Length;
                var maters = new Material[size];
                var materials = i.materials;
			
                for (int k = 0; k < size; k++)
                {
					

                    materials[k] = new Material(Shader.Find("Standard"));
					
                    materials[k].name = i.materials[k].name;
					
                    var m = materials[k];

                    string updatedName = m.name.Replace(" (Instance)", "");
					
					doochsoostiss[updatedName] = 
					i.materials[k];
					
					
                    ClothMaterials[updatedName] = i.materials[k];

                }
                //    i.materials = materials;
            }

			
            processClothColors(new Davar(clothes));
        }

        private void processClothColors(Davar temp)
        {
            foreach (var x in temp)
            {
                ChangeCloth(x.Key, x.Value as string);
            }
        }
		
		public void ChangeOutfit(JsValue outfit) {
			processClothColors(
				new Davar(outfit)
			);
		}
		
        public void ChangeCloth(string clothName, string colorName)
        {
			var realName = clothName;
			if(customMap != null) {
				if(
					customMap.ContainsKey(clothName)
				) {
					realName = customMap[clothName] 
						as string;
				}
			}
            Color myCol;
            if (ColorUtility.TryParseHtmlString(colorName, out myCol))
            {
                if (ClothMaterials.ContainsKey(realName))
                {

                    ClothMaterials[realName].color = myCol;

                }
                else
                {


                }

            }
            else
            {
                print("color didn't work:" + clothName + ", with color:" + colorName);
            }
        }
    }
}
