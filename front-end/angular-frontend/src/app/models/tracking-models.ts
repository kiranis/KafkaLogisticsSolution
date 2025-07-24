export interface ScanEvent {
  scanId: string;
  packageId: string;
  location: string;
  timestamp: string;
  scanType: string;
}

export interface ETAPrediction {
  packageId: string;
  predictedDeliveryTime: string;
  currentLocation: string;
  nextLocation: string;
  confidence: number;
}