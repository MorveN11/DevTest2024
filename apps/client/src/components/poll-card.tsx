import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '@/components/ui/card';
import { Poll } from '@/models/poll.model';

import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from '@/components/ui/dialog';

import { VoteForm } from '@/components/forms/vote-form';

export function PollCard({ poll }: { poll: Poll }) {
  return (
    <Card className="relative w-full">
      <CardHeader>
        <CardTitle>{poll.name}</CardTitle>
        <CardDescription>Total Votes: {poll.totalVotes}</CardDescription>
      </CardHeader>
      <CardContent>
        <Dialog>
          <DialogTrigger asChild>
            <Button className="absolute top-2 right-2" variant="outline">
              Vote
            </Button>
          </DialogTrigger>
          <DialogContent className="sm:max-w-md">
            <DialogHeader>
              <DialogTitle>Vote</DialogTitle>
              <DialogDescription>{poll.name}</DialogDescription>
            </DialogHeader>

            <VoteForm poll={poll} />
          </DialogContent>
        </Dialog>

        <ul className="flex flex-col gap-4">
          {poll.options.map((option) => {
            return (
              <div key={option.id} className="flex w-full justify-between">
                <span className="block">{option.name}</span>
                <span className="block">{option.votesPercentage} %</span>
              </div>
            );
          })}
        </ul>
      </CardContent>
    </Card>
  );
}
