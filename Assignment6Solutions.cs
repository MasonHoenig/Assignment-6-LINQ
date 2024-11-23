using System;
using System.Collections.Generic;

public static partial class Assignment6 {
	private static void Task1(List<Division> nhl) {
		nhl.SelectMany(a => a.Members)
			.ToList()
			.ForEach(team => Console.WriteLine($"{team.Name} {team.City}, {team.Province} ({team.Country}) - Founded {team.YearFounded}"));
	}

	private static void Task2(List<Division> nhl) {
		nhl.SelectMany(a => a.Members)
			.OrderBy(a => a.YearFounded)
			.Take(6)
			.ToList()
			.ForEach(Console.WriteLine);
	}

	private static void Task3(List<Division> nhl) {
		nhl.SelectMany(a => a.Members)
			.Select(a => a.Province)
			.Distinct()
			.OrderBy(province => province)
			.ToList()
			.ForEach(Console.WriteLine);
    }

	private static void Task4(List<Division> nhl) {
        Console.WriteLine(nhl.SelectMany(a => a.Members)
            .Count(a => a.Province == "NY"));
    }

	private static void Task5(List<Division> nhl) {
		nhl.SelectMany(a => a.Members)
			.GroupBy(a => a.Country)
			.Select(a => new { Country = a.Key, Count = a.Count() })
			.ToList()
			.ForEach(team => Console.WriteLine($"{team.Country}: {team.Count} team(s)"));
    }

	private static void Task6(List<Division> nhl) {
        nhl.OrderBy(a => a.Members.Average(a => a.YearFounded))
			.ToList()
			.ForEach(Console.WriteLine);
    }

	private static void Task7(List<Division> nhl) {
		Team? newest = nhl.SelectMany(a => a.Members)
			.MaxBy(a => a.YearFounded);

		Console.WriteLine(newest?.Name);
    }

	private static void Task8(List<Division> nhl) {
        Team? hurricanes = nhl.SelectMany(division => division.Members)
        .FirstOrDefault(team => team.Name.Contains("Hurricanes"));

		Console.WriteLine(2006 - hurricanes?.YearFounded);
    }
}