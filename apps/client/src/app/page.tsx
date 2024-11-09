import { getAllPolls } from '@/api/poll.api';

import { PollHeader } from '@/components/poll-header';
import { PollCard } from '@/components/poll-card';

export default async function Home() {
  const polls = await getAllPolls();

  return (
    <div className="flex flex-1 items-center justify-center">
      <div className="w-full max-w-3xl flex flex-col gap-10">
        <PollHeader />

        <div className="flex flex-col gap-4">
          {polls.map((poll) => {
            return <PollCard key={poll.id} poll={poll} />;
          })}
        </div>
      </div>
    </div>
  );
}
