export const forCheck = async (fn: () => Promise<boolean> | boolean): Promise<void> => {
  while (true) {
    let r = fn();
    if (r instanceof Promise)
      r = await r;
    if (r) break;
    await new Promise((r) => setTimeout(r, 1));
  }
};
