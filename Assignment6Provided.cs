using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public static partial class Assignment6 {
	public static void Main() {
		Division atlantic = new Division("Atlantic");
		atlantic.Members.Add(new Team("Boston Bruins", "Boston", "MA", Country.USA, 1924));
		atlantic.Members.Add(new Team("Buffalo Sabres", "Buffalo", "NY", Country.USA, 1970));
		atlantic.Members.Add(new Team("Detroit Red Wings", "Detroit", "MI", Country.USA, 1926));
		atlantic.Members.Add(new Team("Florida Panthers", "Sunrise", "FL", Country.USA, 1993));
		atlantic.Members.Add(new Team("Montreal Canadiens", "Montreal", "QC", Country.CAN, 1909));
		atlantic.Members.Add(new Team("Ottawa Senators", "Ottawa", "ON", Country.CAN, 1992));
		atlantic.Members.Add(new Team("Tampa Bay Lightning", "Tampa", "FL", Country.USA, 1992));
		atlantic.Members.Add(new Team("Toronto Maple Leafs", "Toronto", "ON", Country.CAN, 1917));

		Division metropolitan = new Division("Metropolitan");
		metropolitan.Members.Add(new Team("Carolina Hurricanes", "Raleigh", "NC", Country.USA, 1972));
		metropolitan.Members.Add(new Team("Columbus Blue Jackets", "Columbus", "OH", Country.USA, 2000));
		metropolitan.Members.Add(new Team("New Jersey Devils", "Newark", "NJ", Country.USA, 1974));
		metropolitan.Members.Add(new Team("New York Islanders", "Brooklyn", "NY", Country.USA, 1972));
		metropolitan.Members.Add(new Team("New York Rangers", "New York", "NY", Country.USA, 1926));
		metropolitan.Members.Add(new Team("Philadelphia Flyers", "Philadelphia", "PA", Country.USA, 1967));
		metropolitan.Members.Add(new Team("Pittsburgh Penguins", "Pittsburgh", "PA", Country.USA, 1967));
		metropolitan.Members.Add(new Team("Washington Capitals", "Washington", "DC", Country.USA, 1974));

		Division central = new Division("Central");
		central.Members.Add(new Team("Arizona Coyotes", "Glendale", "AZ", Country.USA, 1972));
		central.Members.Add(new Team("Chicago Blackhawks", "Chicago", "IL", Country.USA, 1926));
		central.Members.Add(new Team("Colorado Avalanche", "Denver", "CO", Country.USA, 1972));
		central.Members.Add(new Team("Dallas Stars", "Dallas", "TX", Country.USA, 1967));
		central.Members.Add(new Team("Minnesota Wild", "St. Paul", "MN", Country.USA, 2000));
		central.Members.Add(new Team("Nashville Predators", "Nashville", "TN", Country.USA, 1998));
		central.Members.Add(new Team("St. Louis Blues", "St. Louis", "MO", Country.USA, 1967));
		central.Members.Add(new Team("Winnipeg Jets", "Winnipeg", "MB", Country.CAN, 1999));

		Division pacific = new Division("Pacific");
		pacific.Members.Add(new Team("Anaheim Ducks", "Anaheim", "CA", Country.USA, 1993));
		pacific.Members.Add(new Team("Calgary Flames", "Calgary", "AB", Country.CAN, 1972));
		pacific.Members.Add(new Team("Edmonton Oilers", "Edmonton", "AB", Country.CAN, 1972));
		pacific.Members.Add(new Team("Los Angeles Kings", "Los Angeles", "CA", Country.USA, 1967));
		pacific.Members.Add(new Team("San Jose Sharks", "San Jose", "CA", Country.USA, 1991));
		pacific.Members.Add(new Team("Seattle Kraken", "Seattle", "WA", Country.USA, 2021));
		pacific.Members.Add(new Team("Vancouver Canucks", "Vancouver", "BC", Country.CAN, 1970));
		pacific.Members.Add(new Team("Vegas Golden Knights", "Las Vegas", "NV", Country.USA, 2017));

		List<Division> nhl = new List<Division>() { atlantic, metropolitan, central, pacific };

		Console.WriteLine("NHL Overview:");
		Task1(nhl);

		Console.WriteLine("\nOriginal Six:");
		Task2(nhl);

		Console.WriteLine("\nStates & Provinces:");
		Task3(nhl);

		Console.WriteLine("\nNumber of Teams from New York:");
		Task4(nhl);

		Console.WriteLine("\nNumber of Teams from each nation:");
		Task5(nhl);

		Console.WriteLine("\nDivisions (Oldest -> Newest):");
		Task6(nhl);

		Console.WriteLine("\nThe newest team in the league:");
		Task7(nhl);

		Console.WriteLine("\nNumber of years it took for the Hurricanes to win the Stanley Cup:");
		Task8(nhl);
	}
}

public enum Country {
	USA, CAN,
}

public sealed class Team {
	private string name;
	private string city;
	private string province;
	private int yearFounded;

	public Team(string name, string city, string province, Country country, int yearFounded) {
		Name = name;
		City = city;
		Province = province;
		Country = country;
		YearFounded = yearFounded;
	}

	public override string ToString() {
		return name;
	}

	public string Name {
		get => name;

		[MemberNotNull(nameof(name))]
		set {
			if (string.IsNullOrEmpty(value)) {
				throw new ArgumentNullException(nameof(Name));
			}

			name = value;
		}
	}

	public string City {
		get => city;

		[MemberNotNull(nameof(city))]
		set {
			if (string.IsNullOrEmpty(value)) {
				throw new ArgumentNullException(nameof(City));
			}

			city = value;
		}
	}

	public string Province {
		get => province;

		[MemberNotNull(nameof(province))]
		set {
			if (string.IsNullOrEmpty(value)) {
				throw new ArgumentNullException(nameof(Province));
			}

			province = value;
		}
	}

	public Country Country {
		get; set;
	}

	public int YearFounded {
		get => yearFounded;

		set {
			if (value < 1900 || value > DateTime.Now.Year + 2) {
				throw new ArgumentOutOfRangeException(nameof(YearFounded));
			}

			yearFounded = value;
		}
	}
}

public sealed class Division {
	private string name;
	private readonly List<Team> members;

	public Division(string name) {
		Name = name;
		members = new List<Team>();
	}

	public Division(string name, List<Team> members) {
		Name = name;
		this.members = members;
	}

	public override string ToString() {
		return $"{name} Division";
	}

	public string Name {
		get => name;

		[MemberNotNull(nameof(name))]
		set {
			if (string.IsNullOrEmpty(value)) {
				throw new ArgumentNullException(nameof(Name));
			}

			name = value;
		}
	}

	public List<Team> Members {
		get => members;
	}
}