using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Фигуры_2
{
    [Serializable]
    class MFigures
    {
        public List<Figure> mfigures { get; private set; } = new List<Figure>();
        
        public void AddFigure(Figure figure)
        {
            mfigures.Add(figure);
        }
        public void RemoveFigure(Figure figure)
        {
            mfigures.Remove(figure);
        }
        public void AllRemoveFigure()
        {
            for (int i = 0; i < mfigures.Count; i++)
            {
                mfigures.Remove(mfigures[i]);
            }
        }
        public void Save(string filename)
        {
            FileStream file = new FileStream(filename, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(file, this);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                file.Close();
            }
        }
        public static MFigures Restore(string filename)
        {
            MFigures list;
            FileStream file = new FileStream(filename, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                list = (MFigures)formatter.Deserialize(file);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                file.Close();
            }
            return list;
        }
        public Figure Hit(int x,int y)
        {
            Figure figure = null;
            foreach (Figure fig in mfigures)
            {
                if (fig.IsIn(x,y))
                {
                    figure = fig;
                    fig.choice = false;
                }
            }
            return figure;
        }
    }
}
