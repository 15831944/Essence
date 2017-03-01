﻿using System;
using System.Collections.Generic;

namespace Essence.Math.Double.Curves
{
    public class ComposedCurve2 : MultiCurve2
    {
        public void Add(ICurve2 curve)
        {
            if (this.segments.Count == 0)
            {
                this.segments.Add(curve);
            }
            else
            {
                ICurve2 last = this.segments[this.segments.Count - 1];
                double tmin = last.TMax;
                double tlen = curve.TMax - curve.TMin;
                curve.SetTInterval(tmin, tmin + tlen);
            }
        }

        public void SetClosed(bool closed)
        {
            this.closed = closed;
        }

        protected override double GetTMin(int indice)
        {
            return this.segments[indice].TMin;
        }

        protected override double GetTMax(int indice)
        {
            return this.segments[indice].TMax;
        }

        #region Position and derivatives

        protected override Vec2d GetPosition(int index, double tInSegment)
        {
            return this.segments[index].GetPosition(tInSegment);
        }

        protected override Vec2d GetFirstDerivative(int index, double tInSegment)
        {
            return this.segments[index].GetFirstDerivative(tInSegment);
        }

        protected override Vec2d GetSecondDerivative(int index, double tInSegment)
        {
            return this.segments[index].GetSecondDerivative(tInSegment);
        }

        protected override Vec2d GetThirdDerivative(int index, double tInSegment)
        {
            return this.segments[index].GetThirdDerivative(tInSegment);
        }

        #endregion

        #region Differential geometric quantities

        protected override double GetSpeed(int index, double tInSegment)
        {
            return this.segments[index].GetSpeed(tInSegment);
        }

        protected override double GetLength(int index, double tInSegment0, double tInSegment1)
        {
            return this.segments[index].GetLength(tInSegment0, tInSegment1);
        }

        protected override Vec2d GetTangent(int index, double tInSegment)
        {
            return this.segments[index].GetTangent(tInSegment);
        }

        protected override Vec2d GetLeftNormal(int index, double tInSegment)
        {
            return this.segments[index].GetLeftNormal(tInSegment);
        }

        protected override void GetFrame(int index, double tInSegment, ref Vec2d position, ref Vec2d tangent, ref Vec2d normal)
        {
            this.segments[index].GetFrame(tInSegment, ref position, ref tangent, ref normal);
        }

        protected override double GetCurvature(int index, double tInSegment)
        {
            return this.segments[index].GetCurvature(tInSegment);
        }

        #endregion

        protected override void FindIndex(double t, out int index, out double tInSegment)
        {
            index = this.segments.BinarySearch(new CurveForSearch(t), CurveComparer.Instance);
            tInSegment = t;
        }

        protected override int SegmentsCount
        {
            get { return this.segments.Count; }
        }

        public override bool IsClosed
        {
            get { return this.closed; }
        }

        #region private

        private bool closed = false;
        private readonly List<ICurve2> segments = new List<ICurve2>();

        #endregion

        #region Inner clases

        private sealed class CurveComparer : IComparer<ICurve2>
        {
            public static readonly CurveComparer Instance = new CurveComparer();

            public int Compare(ICurve2 x, ICurve2 y)
            {
                return x.TMin.CompareTo(y.TMin);
            }
        }

        private sealed class CurveForSearch : ICurve2
        {
            public CurveForSearch(double t)
            {
                this.TMin = t;
            }

            bool ICurve2.IsClosed
            {
                get { throw new NotImplementedException(); }
            }

            double ICurve2.TMax
            {
                get { throw new NotImplementedException(); }
            }

            public double TMin { get; private set; }

            double ICurve2.TotalLength
            {
                get { throw new NotImplementedException(); }
            }

            double ICurve2.GetCurvature(double t)
            {
                throw new NotImplementedException();
            }

            Vec2d ICurve2.GetFirstDerivative(double t)
            {
                throw new NotImplementedException();
            }

            void ICurve2.GetFrame(double t, ref Vec2d position, ref Vec2d tangent, ref Vec2d normal)
            {
                throw new NotImplementedException();
            }

            Vec2d ICurve2.GetLeftNormal(double t)
            {
                throw new NotImplementedException();
            }

            double ICurve2.GetLength(double t0, double t1)
            {
                throw new NotImplementedException();
            }

            Vec2d ICurve2.GetPosition(double t)
            {
                throw new NotImplementedException();
            }

            Vec2d ICurve2.GetSecondDerivative(double t)
            {
                throw new NotImplementedException();
            }

            double ICurve2.GetSpeed(double t)
            {
                throw new NotImplementedException();
            }

            Vec2d ICurve2.GetTangent(double t)
            {
                throw new NotImplementedException();
            }

            Vec2d ICurve2.GetThirdDerivative(double t)
            {
                throw new NotImplementedException();
            }

            void ICurve2.SetTInterval(double tmin, double tmax)
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}