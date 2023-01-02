﻿using ParticleSwarmSharp;
using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Particles;
using ParticleSwarmSharp.Populations;
using ParticleSwarmSharp.Termination;

Random random = new();

int populationSize = 3;

List<ClassicParticle> particles = new();

for (int i = 0; i < populationSize; i++)
{
    particles.Add(new ClassicParticle(1));
}

IPopulation population = new Population(populationSize);

population.CreateGeneration(particles);

IFitnessFunction fitness = new FuncFitness((particle) =>
{
    double x = particle.Position[0];

    return Math.Sin(x) + Math.Sin(10.0 / 3.0 * x);
});

IParticleSwarm pso = new ParticleSwarm(
    population,
    fitness,
    new GenerationCountTermination(50));

pso.GenerationComplete += (s, e) =>
{
    Console.WriteLine(e.ToString());
};

pso.TerminationCriteriaReached += (s, e) =>
{
    Console.WriteLine("Termination criteria reached");
};

pso.Stopped += (s, e) =>
{
    Console.WriteLine("Stopped");
};

pso.Start();