enum Shape {
    RECTANGLE = 0,
    CIRCLE = 1,
    POLYGON = 2
}

interface Point {
    x: number,
    y: number
}

export interface IRoom {
    number: number,
    floor: number,
    buildingName: string,
    points: Point[],
    shape: Shape,
    capacity?: number
  }
