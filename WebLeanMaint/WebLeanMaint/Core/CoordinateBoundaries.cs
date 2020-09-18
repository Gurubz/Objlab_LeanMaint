using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Core
{
	/// <summary>
	/// Calculates the upper, lower, left and right coordinate boundaries based on an origin point and a distance.
	/// </summary>
	public class CoordinateBoundaries
	{
		private double _latitude;

		/// <summary>
		/// The origin point latitude in decimal notation
		/// </summary>
		public double Latitude
		{
			get { return _latitude; }

			set
			{
				_latitude = value;
				Calculate();
			}
		}

		private double _longitude;

		/// <summary>
		/// The origin point longitude in decimal notation
		/// </summary>
		public double Longitude
		{
			get { return _longitude; }
			set
			{
				_longitude = value;
				Calculate();
			}
		}

		private double _distance;

		/// <summary>
		/// The distance in statue miles from the origin point
		/// </summary>
		public double Distance
		{
			get { return _distance; }
			set
			{
				_distance = value;
				Calculate();
			}
		}

		/// <summary>
		/// The lower boundary latitude point in decimal notation
		/// </summary>
		public double MaxLatitude { get; private set; }

		/// <summary>
		/// The upper boundary latitude point in decimal notation
		/// </summary>
		public double MinLatitude { get; private set; }

		/// <summary>
		/// The right boundary longitude point in decimal notation
		/// </summary>
		public double MaxLongitude { get; private set; }

		/// <summary>
		/// The left boundary longitude point in decimal notation
		/// </summary>
		public double MinLongitude { get; private set; }

		/// <summary>
		/// Creates a new CoordinateBoundary object
		/// </summary>
		public CoordinateBoundaries()
		{
		}

		/// <summary>
		/// Creates a new CoordinateBoundary object
		/// </summary>
		/// <param name="originCoordinate">A <see cref="Coordinate"/> object representing the origin location</param>
		/// <param name="distance">The distance from the origin point in statute meters</param>
		public CoordinateBoundaries(GeoCoordinate originCoordinate, double distance)
				: this(originCoordinate.Latitude, originCoordinate.Longitude, distance) { }

		/// <summary>
		/// Creates a new CoordinateBoundary object
		/// </summary>
		/// <param name="latitude">The origin point latitude in decimal notation</param>
		/// <param name="longitude">The origin point longitude in decimal notation</param>
		/// <param name="distance">The distance from the origin point in statute meters</param>
		public CoordinateBoundaries(double latitude, double longitude, double distance)
		{
			_latitude = latitude;
			_longitude = longitude;
			_distance = distance;

			Calculate();
		}

		private void Calculate()
		{
			try
			{
				GeoCoordinate o = new GeoCoordinate(_latitude, _longitude);
			}
			catch
			{
				throw new ArgumentException("Invalid coordinates supplied.");
			}

			double latitudeConversionFactor = Distance;
			double latitudeInRadian = (Math.PI / 180) * Latitude;
			double longitudeConversionFactor = Distance / Math.Abs(Math.Cos(latitudeInRadian));

			MinLatitude = Latitude - latitudeConversionFactor;
			MaxLatitude = Latitude + latitudeConversionFactor;

			MinLongitude = Longitude - longitudeConversionFactor;
			MaxLongitude = Longitude + longitudeConversionFactor;

			// Adjust for passing over coordinate boundaries
			if (MinLatitude < -90) MinLatitude = 90 - (-90 - MinLatitude);
			if (MaxLatitude > 90) MaxLatitude = -90 + (MaxLatitude - 90);

			if (MinLongitude < -180) MinLongitude = 180 - (-180 - MinLongitude);
			if (MaxLongitude > 180) MaxLongitude = -180 + (MaxLongitude - 180);
		}
	}
}