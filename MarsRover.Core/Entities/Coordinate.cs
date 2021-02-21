using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{

    public struct Coordinate
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    // class olarak kullanıldığında unit testlerde 2-3 ms olarak gidip geldi (Struct yapısında ise stabil 2ms şeklinde idi). Bilgisayarı yoğun olarak kullandıkça bu fark açıldı o yüzden struct tercih  edildi.
    //public class Coordinate
    //{
    //    public int x { get; set; }
    //    public int y { get; set; }

    //}

    //public enum Direction
    //{
    //    W = 0,
    //    N = 90,
    //    E = 180,
    //    S = 270
    //}

}
