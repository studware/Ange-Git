using System;
using System.Linq;
using System.IO;

namespace T1.Algo2.Salaries
{
    class Salaries
    {
        static void Main()
        {
            Console.SetIn(new StringReader(
                            @"4
                              NNYN
                              NNYN
                              NNNN
                              NYYN"));
            var countOfPersonnel = int.Parse(Console.ReadLine());

            // Find the spanning forest's directed paths
            var salary = new long[countOfPersonnel];
            var managedCount = new long[countOfPersonnel];

            // Form the adjacency matrix
            var edge = new bool[countOfPersonnel, countOfPersonnel];

            for (var iNode = 0; iNode < countOfPersonnel; ++iNode)
            {
                var jNode = 0;

                foreach (var ch in Console.ReadLine().Trim())
                {
                    edge[iNode, jNode] = (ch == 'Y');
                    managedCount[iNode] += edge[iNode, jNode] ? 1 : 0;
                    jNode += 1;
                }

                if (managedCount[iNode] == 0)
                {
                    salary[iNode] = 1;
                }
            }

            Func<int, long> getSalary = null;

            getSalary = iNode =>
            {
                if (salary[iNode] == 0)
                {
                    for (var jNode = 0; jNode < countOfPersonnel; ++jNode)
                    {
                        if (edge[iNode, jNode])
                            salary[iNode] += getSalary(jNode);
                    }
                }
                return salary[iNode];
            };

            long totalSalary = Enumerable.Range(0, countOfPersonnel)
                                   .OrderBy(who => managedCount[who])
                                   .Select(getSalary)
                                   .Sum();

            Console.WriteLine(totalSalary);
        }
    }
}
