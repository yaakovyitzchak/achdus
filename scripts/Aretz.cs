using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Achdus {
    public class Aretz : Heeoolee {
        public Aretz(string heightmap = null) {
            var data = new TerrainData();
            if (heightmap != null) {
                var texture = Tzirum.Textures[heightmap];
                MakeActualTerrain(data, texture);
            }
            else {
                Debug.Log("nope");
                data.size = new Vector3(200, 200, 200);
                data.thickness = 100;
            }


            var terr = Terrain.CreateTerrainGameObject(data);
            var mat = new Material(Shader.Find("Diffuse"));
            mat.color = new Color(0.3f, 0.2f, 0.5f);
            terr.GetComponent<Terrain>().materialTemplate = mat;
            Debug.Log(mat);
            gameObject = terr;
        }

        private void MakeActualTerrain(TerrainData data, Texture2D inputHeightmapTexture) {

            var texture = inputHeightmapTexture;
            Debug.Log(texture);


            data.heightmapResolution = Math.Max(texture.width, texture.height);

            int resolution = data.heightmapResolution;
            resolution = data.heightmapResolution;

            float[,] heights = new float[resolution, resolution];

            float ratioW = resolution / (float)texture.width;
            float ratioH = resolution / (float)texture.height;
            data.size = new Vector3(texture.width, 200, texture.height);

            texture = PowerUI.ImageResizer.Resize(texture, ratioH, ratioW);
            var pixels = texture.GetPixels();
            var index = 0;

            heights = new float[resolution, resolution];
       //     Debug.Log("rez " + resolution + " : " + data.size + " : " + texture.width + " : " + texture.height);
            for (var x = 0; x < texture.width; x++) {
                for (var y = 0; y < texture.height; y++) {
                    heights[x, y] = 1 - pixels[index].r;
                    index++;
                }
            }

            data.SetHeights(0, 0, heights);
        }
    }
}