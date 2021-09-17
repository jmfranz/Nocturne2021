using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Media.Media3D;
using System.Numerics;


namespace ProxemicUIFramework
{
    public class CircularFformation : Fformation
    {
        private Position _CenterPoint;
        private double _Radius;
        private List<string> _ListOfEntities = new List<string>();
        private List<FormationEntities> _FormationEntities = new List<FormationEntities>(); 
        private bool _FirstMethodCall = true, _UpdateFormation;
        private List<double> _NewAngels = new List<double>();

        public CircularFformation(Vector3 CenterPoint, double Radius, List<string> ListOfEntities)
        {
            _CenterPoint.X = CenterPoint.X;
            _CenterPoint.Y = CenterPoint.Y;
            _CenterPoint.Z = CenterPoint.Z;
            _Radius = Radius;
            _ListOfEntities = ListOfEntities;
            base.Entities = ListOfEntities;
            //CreateFormation();
        }

        public void UpdateFormation(double Radius, List<string> ListOfEntities)
        {
            _Radius = Radius;
            _ListOfEntities = ListOfEntities;
            _UpdateFormation = true;
            base.Entities = ListOfEntities;
            //CreateFormation();
        }

        //private void CreateFormation()
        internal override void CreateFormation()
        {
            FformationEventArgs eventArgs = new FformationEventArgs();

            foreach (string id in _ListOfEntities)
            {
                FormationEntities entity = new FormationEntities();
                entity.ID = id;
                entity.CurrentPosition = EntityContainer.ListOfEntities[id].GetPosition();
                entity.CurrentOrientation = EntityContainer.ListOfEntities[id].GetOrientation();
                entity.ClosestPoint = CalculateClosestPoint(entity.CurrentPosition);
                entity.CurrentAngleFromCenter = CalculateCurrentAngle(entity.CurrentPosition);
                entity.NewAngleFromCenter = CalculateNewAngle(entity.CurrentAngleFromCenter);
                entity.NewPosition = CalculateNewPosition(entity.NewAngleFromCenter, entity.CurrentPosition);
                entity.NewOrientation = CalculateNewOrientation(entity.NewPosition, entity.CurrentOrientation);

                _FormationEntities.Add(entity);
            }

            List<Tuple<string, Position, Orientation>> tuples = new List<Tuple<string, Position, Orientation>>();

            foreach(FormationEntities entity in _FormationEntities)
            {
                tuples.Add(new Tuple<string, Position, Orientation>(entity.ID, entity.NewPosition, entity.NewOrientation));
            }

            eventArgs.TuplesForFformation = tuples;
            if (_UpdateFormation)
            {
                base.FireEventUpdated(this, eventArgs);
                RuleEngine.Instance.RemoveFromFormationList(this);
            }
            else
            {
                base.FireEventCompleted(this, eventArgs);
                RuleEngine.Instance.RemoveFromFormationList(this);
            }
        }

        private Position CalculateClosestPoint(Position point)
        {
            double angleX = point.X - _CenterPoint.X;
            double angleZ = point.Z - _CenterPoint.Z;
            double angle = Math.Sqrt(angleX * angleX + angleZ * angleZ);

            Position closestPoint = new Position((_CenterPoint.X + angleX / angle * _Radius), point.Y, (_CenterPoint.Z + angleZ / angle * _Radius));

            return closestPoint;
        }

        private void CalculateAnglesForEntities(double angle)
        {
            double angleBetweenEntities = 360 / _ListOfEntities.Count;
            double currentAngle = angle;
            for (int i = 0; i < _ListOfEntities.Count-1; i++)
            {
                currentAngle += angleBetweenEntities;

                if (currentAngle > 360)
                    currentAngle -= 360;

                _NewAngels.Add(currentAngle);
            }
        }

        private Position CalculateNewPosition(double angle, Position position)
        {
            // convert angle to radians
            double radians = (Math.PI / 180) * angle;

            Position p = new Position();
            p.X = _CenterPoint.X + Math.Cos(radians) * _Radius;
            p.Z = _CenterPoint.Z + Math.Sin(radians) * _Radius;
            p.Y = position.Y;

            return p;
        }
        // angle from the center of the circle (to position entities around the center)
        private double CalculateNewAngle(double angle)
        {
            // if it is the first call, we take the angle for the first entity as a starting angle
            if (_FirstMethodCall)
            {
                CalculateAnglesForEntities(angle);
                _FirstMethodCall = false;
                return angle;
            }
            else
            {
                // calculate closest angle to the current angle for this entity
                double closestAngle = _NewAngels.Aggregate((x, y) => Math.Abs(x - angle) < Math.Abs(y - angle) ? x : y);
                // remove the new angle from the list to not use it in the future.
                _NewAngels.Remove(closestAngle);
                return closestAngle;
            }
        }

        private double CalculateCurrentAngle(Position position)
        {
            double radians = Math.Atan2(position.Z -_CenterPoint.Z, position.X - _CenterPoint.X);

            double degree = ((radians * (180 / Math.PI)) + 360) % 360;

            return degree;
        }
        // orientation relative to the center of the circle (to make all entities face the center)
        private Orientation CalculateNewOrientation(Position position, Orientation orientation)
        {
            double radians = Math.Atan2(position.Z - _CenterPoint.Z, position.X - _CenterPoint.X);

            double degree = ((radians * (180 / Math.PI)) + 360) % 360;

            return new Orientation(degree, orientation.Pitch, orientation.Roll);
        }

        private struct FormationEntities
        {
            string _id;
            double _currentAngle, _newAngle;
            Orientation _currentOrientation, _newOrientation;
            Position _currentPosition, _newPosition, _closestPoint;

            public string ID
            {
                get { return _id; }
                set { _id = value; }
            }
            // gives at which angle is this entity from the center of the circle
            public double CurrentAngleFromCenter
            {
                get { return _currentAngle; }
                set { _currentAngle = value; }
            }

            public double NewAngleFromCenter
            {
                get { return _newAngle; }
                set { _newAngle = value; }
            }

            public Position CurrentPosition
            {
                get { return _currentPosition; }
                set { _currentPosition = value; }
            }

            public Position ClosestPoint
            {
                get { return _closestPoint; }
                set { _closestPoint = value; }
            }
            public Position NewPosition
            {
                get { return _newPosition; }
                set { _newPosition = value; }
            }

            public Orientation CurrentOrientation
            {
                get { return _currentOrientation; }
                set { _currentOrientation = value; }
            }

            public Orientation NewOrientation
            {
                get { return _newOrientation; }
                set { _newOrientation = value; }
            }

            public FormationEntities(string id, double currentAngle, double newAngle, Position currentPosition, Position newPosition, Position closestPoint, Orientation currentOrientation, Orientation newOrientation)
            {
                this._id = id;
                this._currentPosition = currentPosition;
                this._currentAngle = currentAngle;
                this._newPosition = newPosition;
                this._newAngle = newAngle;
                this._closestPoint = closestPoint;
                this._currentOrientation = currentOrientation;
                this._newOrientation = newOrientation;
            }
        }
    }
}
