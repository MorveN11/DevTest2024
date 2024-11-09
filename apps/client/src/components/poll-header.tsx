import { Button } from '@/components/ui/button';

export function PollHeader() {
  return (
    <div className="w-full flex justify-between px-12 items-center">
      <h2 className="text-xl font-bold">Poll List</h2>
      <Button>Add New</Button>
    </div>
  );
}
