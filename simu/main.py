# multi-robot-warehouse-scheduling (MRWS)
# Steven X. Dai
# 2023

import matplotlib.pyplot as plt


class Scheduler:
    def __init__(self):
        pass


class Robot:
    def __init__(self):
        pass


class Station:
    def __init__(self):
        pass


class Cargo:
    def __init__(self):
        pass


class Map:
    def __init__(self):
        pass


class Simulator:
    def __init__(self):
        self.timestamp = 0
        pass

    def add_robot(self):
        pass

    def add_cargo(self):
        pass

    def add_map(self):
        pass

    def run(self):
        x = 0
        y = 0

        # Set the axis limits for the plot
        plt.axis([0, 1000, 0, 1000])

        while self.timestamp < 1000:
            print("MRWS - Running")

            x += 1.1
            y += 1.1

            # visualisation
            if self.timestamp % 10 == 0:
                plt.scatter(x, y)
                plt.pause(0.001)

            self.timestamp += 1


if __name__ == "__main__":
    simu = Simulator()
    simu.run()
