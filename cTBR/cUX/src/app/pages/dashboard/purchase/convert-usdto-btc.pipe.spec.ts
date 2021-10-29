import { ConvertUSDToBTCPipe } from './convert-usdto-btc.pipe';

describe('ConvertUSDToBTCPipe', () => {
  it('create an instance', () => {
    const pipe = new ConvertUSDToBTCPipe();
    expect(pipe).toBeTruthy();
  });
});
