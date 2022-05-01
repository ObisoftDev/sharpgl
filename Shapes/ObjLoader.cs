using SharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGL.Shapes
{
    public class ObjLoader
    {
        public static RawModel loadObjModel(string file)
        {
            string[] lines = File.ReadAllLines(file);
            List<Vector3> vertices = new List<Vector3>();
            List<Vector2> textures = new List<Vector2>();
            List<Vector3> normals = new List<Vector3>();
            List<int> indices = new List<int>();
            float[] verticesArray = null;
            float[] normalsArray = null;
            float[] texturesArray = null;
            int[] indicesArray = null;

            foreach(var line in lines)
            {
                string[] currentLine = getFinalVertexArray(line.Split(' '));
                if (line.StartsWith("v "))
                {
                    Vector3 vertex = new Vector3(
                        float.Parse(currentLine[1]),
                        float.Parse(currentLine[2]),
                        float.Parse(currentLine[3]));
                    vertices.Add(vertex);
                }
                else if (line.StartsWith("vt "))
                {
                    Vector2 texture = new Vector2(
                        float.Parse(currentLine[1]),
                        float.Parse(currentLine[2]));
                    textures.Add(texture);
                }
                else if(line.StartsWith("vn "))
                {
                    Vector3 normal = new Vector3(
                       float.Parse(currentLine[1]),
                       float.Parse(currentLine[2]),
                       float.Parse(currentLine[3]));
                    normals.Add(normal);
                }
                else if (line.StartsWith("f "))
                {
                    texturesArray = new float[vertices.Count * 2];
                    normalsArray =  new float[vertices.Count * 3];
                    break;
                }
            }

            foreach (var line in lines)
            {
                if(!line.StartsWith("f ")) continue;

                string[] currentLine = line.Split(' ');

                string[] vertex1 = currentLine[1].Split('/');
                string[] vertex2 = currentLine[2].Split('/');
                string[] vertex3 = currentLine[3].Split('/');

                try
                {
                    processVertex(vertex1, indices, textures, normals, texturesArray, normalsArray);
                    processVertex(vertex2, indices, textures, normals, texturesArray, normalsArray);
                    processVertex(vertex3, indices, textures, normals, texturesArray, normalsArray);
                }
                catch
                {

                }
            }

            verticesArray = new float[vertices.Count * 3];
            indicesArray = indices.ToArray();

            int vertexPonter = 0;

            for (int i=0;i<vertices.Count;i++)
            {
                verticesArray[vertexPonter++] = vertices[i].X;
                verticesArray[vertexPonter++] = vertices[i].Y;
                verticesArray[vertexPonter++] = vertices[i].Z;
            }

            return ShapeLoader.loadToVAO(verticesArray,texturesArray,normalsArray, indicesArray);
        }

        public static string[] getFinalVertexArray(string[] array)
        {
            List<string> final = new List<string>();
            for (int i = 0; i < array.Length; i++)
                if (array[i] != "")
                    final.Add(array[i]);
            return final.ToArray();
        }


        public static void processVertex(string[] vertexData,List<int> indices,List<Vector2> textures,List<Vector3> normals,
            float[] texturesArray,float[] normalsArray)
        {

            int currentVertexPointer = int.Parse(vertexData[0]) - 1;
            indices.Add(currentVertexPointer);

            Vector2 currentTex = textures[int.Parse(vertexData[1])-1];
            texturesArray[currentVertexPointer * 2 + 0] = currentTex.X;
            texturesArray[currentVertexPointer * 2 + 1] = 1 - currentTex.Y;

            Vector3 currentNorm = normals[int.Parse(vertexData[2]) - 1];
            normalsArray[currentVertexPointer * 3 + 0] = currentNorm.X;
            normalsArray[currentVertexPointer * 3 + 1] = currentNorm.Y;
            normalsArray[currentVertexPointer * 3 + 2] = currentNorm.Z;
        }

    }
}
